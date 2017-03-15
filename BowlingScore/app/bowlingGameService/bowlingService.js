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
var http_1 = require('@angular/http');
require('rxjs/add/operator/map');
var BowlingService = (function () {
    function BowlingService(http) {
        this.http = http;
        console.log('BowlingService initialezed ...');
        this.headers = new http_1.Headers();
        this.headers.append('content-type', 'application/json');
    }
    BowlingService.prototype.getScore = function () {
        return this.http.get('http://jsonplaceholder.typicode.com/posts')
            .map(function (res) { return res.json(); });
    };
    BowlingService.prototype.calculateScore = function (postData) {
        return this.http.post('http://localhost:54826/api/Score/CalculateScore', postData, {
            headers: this.headers
        })
            .map(function (res) { return res.json(); });
    };
    BowlingService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], BowlingService);
    return BowlingService;
}());
exports.BowlingService = BowlingService;
//# sourceMappingURL=bowlingService.js.map