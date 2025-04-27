import * as tf from '@tensorflow/tfjs';
import * as use from '@tensorflow-models/universal-sentence-encoder'

import {intents} from './extra/intents.js';
import {responses} from './extra/responses.js';

export class chat {

  constructor() {
    this.model = null;
  }

  getRandomNumber(a, b) {
    return Math.round(Math.random() * (b - a)) + a;
  }

  loadChat() {
    use.load().then((loadedModel) => {
      this.model = loadedModel;
      console.log("Model loaded");
    });
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
    let col_ai = document.getElementsByClassName("label-ai");

    document.currentElement = col_ai;
    document.labelUserOutput = "";
    document.outputReady = false;
    document.writingReady = false;
    document.idIntervals = [];
    document.counter = 0;

    const randomNumbers = [2, 1, 2, 2, 1, 2, 2, 1, 2, 1]; 
    const rndNumber = randomNumbers[this.getRandomNumber(0, randomNumbers.length-1)];

    document.idIntervals[1] = window.setInterval(()=>{
      if (document.outputReady) {
        try {
          document.counter += 1;
          let label = document.currentElement[document.currentElement.length-1];
        
          if (document.counter == 2) { //at least twice, this block code was executed
            document.writingReady = true;

            if (document.labelUserOutput.length != 0) {
              label.innerText = document.labelUserOutput;
            }
              
            window.clearInterval(document.idIntervals[0]);
            window.clearInterval(document.idIntervals[1]);        
          }
        } catch (error) {
          console.log(error);                
          window.clearInterval(document.idIntervals[1]);           
        }
      }
    },1400*rndNumber);

    document.idIntervals[0] = window.setInterval(()=>{
      if (!document.outputReady && !document.writingReady) {
        try {
          let label = document.currentElement[document.currentElement.length-1];
          let text = label.innerText;
          
          if (text == "") { text = "."; }
          else if (text == ".") { text = ".."; }
          else if (text == "..") { text = "..."; }
          else if (text == "...") { text = ""; }
          
          label.innerText = text;          
        } catch (error) {
          console.log(error);
          window.clearInterval(document.idIntervals[0]);
        } 
      }
    },500);

    const userInput = userPrompt;
    const userOutput = await this.generateResponse(userInput);       

    const agentName = "Larry Hart";   
    document.labelUserOutput = `${agentName}: ${userOutput}`;

    document.outputReady = true;

    let ob_header = document.getElementsByClassName("App-header")[0];

    if (typeof(ob_header.scrollTop) != 'undefined') {
        ob_header.scrollTop = ob_header.scrollHeight;
    }            
  }
}
