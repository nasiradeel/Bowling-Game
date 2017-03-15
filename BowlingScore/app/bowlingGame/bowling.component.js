"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var bowlingFrame_1 = require('./bowlingFrame');
var BowlingService_1 = require('../bowlingGameService/BowlingService');
var BowlingComponent = (function () {
    function BowlingComponent(bowlingService) {
        var _this = this;
        this.bowlingService = bowlingService;
        this.rolls = [];
        this.frames = [];
        this.frameCount = 10;
        this.frameTotal = [];
        this.frame = new bowlingFrame_1.bowlingFrame();
        this.bowlingService.calculateScore(JSON.stringify(this.frames)).subscribe(function (score) {
            _this.Score = score;
        });
    }
    Object.defineProperty(BowlingComponent.prototype, "CurrentbowlingFrame", {
        get: function () {
            return JSON.stringify(this.frame);
        },
        enumerable: true,
        configurable: true
    });
    BowlingComponent.prototype.addRoll = function (roll1, roll2) {
        var _this = this;
        this.rolls.push(roll1);
        this.rolls.push(roll2);
        var frame = new bowlingFrame_1.bowlingFrame();
        frame.firstRoll = roll1;
        frame.secondRoll = roll2;
        this.frames.push(frame);
        console.log(this.frames.length);
        console.log(this.frames[0].firstRoll);
        this.bowlingService.calculateScore(JSON.stringify(this.frames)).subscribe(function (score) {
            _this.Score = score;
            _this.frameTotal.push(_this.Score);
        });
    };
    BowlingComponent.prototype.resetGame = function () {
        this.frames = [];
        this.frameTotal = [];
        this.rolls = [];
    };
    BowlingComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'bowling',
            templateUrl: 'bowling.component.html',
            providers: [BowlingService_1.BowlingService]
        }), 
        __metadata('design:paramtypes', [BowlingService_1.BowlingService])
    ], BowlingComponent);
    return BowlingComponent;
}());
exports.BowlingComponent = BowlingComponent;
//# sourceMappingURL=bowling.component.js.map