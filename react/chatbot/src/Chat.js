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

  loadChat(userPrompt) {
    this.userPrompt = userPrompt;

    use.load().then((loadedModel) => {
      this.model = loadedModel;
      console.log("Model loaded");
      this.startChatbot();
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

    if (intent && responses[intent]) {
      return responses[intent];
    } else {
      return "I'm sorry, I don't understand that. Can you please rephrase?";
    }
  }

  startChatbot() {
    let userPrompt = this.userPrompt;

    const send = async (userPrompt) => { 
      const userInput = userPrompt;
      const userOutput = await this.generateResponse(userInput);
      const agentName = "Larry Hart";

      let col_ai = document.getElementsByClassName("label-ai");
      col_ai[col_ai.length-1].innerText = `${agentName}: ${userOutput}`;

      let ob_header = document.getElementsByClassName("App-header")[0];
  
      if (typeof(ob_header.scrollTop) != 'undefined') {
          ob_header.scrollTop = ob_header.scrollHeight;
      }
        
    };

    send(userPrompt);
  }
}
