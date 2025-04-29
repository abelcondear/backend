import * as tf from '@tensorflow/tfjs';
import * as use from '@tensorflow-models/universal-sentence-encoder'

import {intents} from './extra/intents.js';
import {responses} from './extra/responses.js';

export class chat {
  constructor() {
    //this.model = null;
    use.load().then((loadedModel) => {
      this.model = loadedModel;
      console.log("Model loaded");
    });

    document.ob_this = this;
  }

  getRandomNumber(a, b) {
    return Math.round(Math.random() * (b - a)) + a;
  }
  
  moveDownScrollBar() {
    let ob_header = document.getElementsByClassName("App-header")[0];

    if (typeof(ob_header.scrollTop) != 'undefined') {
        ob_header.scrollTop = ob_header.scrollHeight;
    }
  }
  
  async recognizeIntent(userInput) { 
    const userInputEmb = await this.model.embed([userInput]);
    let maxScore = -1;
    let recognizedIntent = null;

    for (const [intent, examples] of Object.entries(intents)) {
      const examplesEmb = await this.model.embed(examples);
      const scores = await tf.matMul(userInputEmb, examplesEmb, false, true).data();
      const maxExampleScore = Math.max(...scores);

      if (maxExampleScore > maxScore) {
        maxScore = maxExampleScore;
        recognizedIntent = intent;
      }
    }

    return recognizedIntent;
  }

  async generateResponse(userInput) {
    const intent = await this.recognizeIntent(userInput);
    const index = (intent) ? this.getRandomNumber(0, responses[intent].length-1):0;
    
    if (intent && responses[intent][index]) {
      return responses[intent][index];
    } else {
      return "I'm sorry, I don't understand that. Can you please rephrase?";
    }
  }

  async send(userPrompt) { 
    document.textbox = document.getElementById("txtInput");
    document.currentElement = document.getElementsByClassName("label-ai");
    document.labelUserOutput = "";
    document.outputReady = false;
    document.writingReady = false;
    document.idIntervals = [];
    document.counter = 0;
    document.maxCounter = 2;

    const randomNumbers = [1, 2, 2, 2, 1, 2, 2, 1, 2, 1]; 
    const rndNumber = randomNumbers[this.getRandomNumber(0, randomNumbers.length-1)];

    document.idIntervals[1] = window.setInterval(()=>{
      if (document.outputReady) {
        try {
          document.counter += 1;
          let label = document.currentElement[document.currentElement.length-1];
        
          if (document.counter == document.maxCounter) { //at least twice, this block code was executed
            document.writingReady = true;

            if (document.labelUserOutput.length != 0) {
              label.innerHTML = document.labelUserOutput;
              document.ob_this.moveDownScrollBar();
              document.textbox.style.backgroundColor = "white";
              document.textbox.readOnly = false;              
              document.textbox.placeholder="";              
            }
              
            window.clearInterval(document.idIntervals[0]);
            window.clearInterval(document.idIntervals[1]);        
          }
        } catch (error) {
          console.log(error);                
          window.clearInterval(document.idIntervals[1]);           
        }
      }
    },2400*rndNumber);

    document.idIntervals[0] = window.setInterval(()=>{
      if (!document.outputReady && !document.writingReady) {
        try {
          let label = document.currentElement[document.currentElement.length-1];
          let text = label.innerText;
          
          if (text == "") { text = "."; }
          else if (text == ".") { text = ". ."; }
          else if (text == ". .") { text = ". . ."; }
          else if (text == ". . .") { text = ". . . ."; }
          else if (text == ". . . .") { text = ". . . . ."; }
          else if (text == ". . . . .") { text = ""; }
          
          label.innerHTML = `<strong>${text}</strong>`;           
          document.ob_this.moveDownScrollBar();
        } catch (error) {
          console.log(error);
          window.clearInterval(document.idIntervals[0]);
        } 
      }
    },200);

    const userInput = userPrompt;
    const userOutput = await this.generateResponse(userInput);       

    const agentName = "Larry Hart";   
    document.labelUserOutput = `<strong>${agentName}</strong>: ${userOutput}`;

    document.outputReady = true;
  }
}
