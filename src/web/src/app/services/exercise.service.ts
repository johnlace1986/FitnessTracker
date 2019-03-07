import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, min } from 'rxjs/operators';
import { IExercise } from '../models/exercise';
import { IDateWrapper } from '../models/date-wrapper';
import { IWeight } from '../models/weight';
import { ITimeSpanWrapper } from '../models/time-span-wrapper';


@Injectable({
  providedIn: 'root'
})
export class ExerciseService {

  private _baseAddress: string = 'http://localhost:5000/api/exercise';

  constructor(private _client: HttpClient) {
  }

  get(): Observable<Array<IExercise>> {
    return this._client.get<Array<IExercise>>(this._baseAddress);
  }

  add(recorded: IDateWrapper, timeTaken: ITimeSpanWrapper, distance: number, caloriesBurned: number): Observable<IExercise> {

    var actualRecorded = recorded.year + '-' + recorded.month + '-' + recorded.day + 'T00:00:00';
    var actualTimeTaken = this.parseTimeSpan(timeTaken);

    return this._client.put<IExercise>(this._baseAddress, {
      recorded: actualRecorded,
      timeTaken: actualTimeTaken,
      distance: distance,
      caloriesBurned: caloriesBurned
    });
  }

  private parseTimeSpan(timeSpan: ITimeSpanWrapper): string {
    let days = timeSpan.days;
    let hours = timeSpan.hours;
    let minutes = timeSpan.minutes;
    let seconds = timeSpan.seconds;

    while (seconds >= 60) {
      minutes++;
      seconds -= 60;
    }

    while (minutes >= 60) {
      hours++;
      seconds -= 60;
    }

    while (hours >= 24) {
      days++;
      hours -= 24;
    }
    
    return `${days}:${this.padNumber(hours, 2)}:${this.padNumber(minutes, 2)}:${this.padNumber(seconds, 2)}`;
  }

  private padNumber(value: number, length: number): string {
    let stringValue = value.toString();
    while (stringValue.length < length) {
      stringValue = '0' + stringValue;
    }

    return stringValue;
  }
}
