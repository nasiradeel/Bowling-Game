import { Component } from '@angular/core';
import { bowlingFrame } from './bowlingFrame';
import { BowlingService } from '../bowlingGameService/BowlingService';

@Component({
    moduleId: module.id,
    selector: 'bowling',
    templateUrl: 'bowling.component.html',
    providers: [BowlingService]
})
export class BowlingComponent {
    roll1: number;
    roll2: number;
    rolls: number[] = [];
    frames: bowlingFrame[] = [];
    frameCount: number = 10;
    frame: bowlingFrame;
    Score: Score;
    frameTotal: Score[] = [];
   
    get CurrentbowlingFrame() {
        return JSON.stringify(this.frame);
    }

    constructor(private bowlingService: BowlingService) {
        this.frame = new bowlingFrame();
        this.bowlingService.calculateScore(JSON.stringify(this.frames)).subscribe(score => {
            this.Score = score;
        });

        
        
    }

    addRoll(roll1: number, roll2: number) {
            this.rolls.push(roll1);
            this.rolls.push(roll2);

            var frame = new bowlingFrame();
            frame.firstRoll = roll1;
            frame.secondRoll = roll2;
            this.frames.push(frame);
            console.log(this.frames.length);
            console.log(this.frames[0].firstRoll);

            this.bowlingService.calculateScore(JSON.stringify(this.frames)).subscribe(score => {
                this.Score = score;
                this.frameTotal.push(this.Score);
            });
    }

    resetGame() {
        this.frames = [];
        this.frameTotal = [];
        this.rolls = [];
    }
}

interface Score {
    totalScore: number;
}

