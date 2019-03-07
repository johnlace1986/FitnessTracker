import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IExerciseGroup } from '../models/exercise-group';
import { IDateWrapper } from '../models/date-wrapper';
import { IWeight } from '../models/weight';


@Injectable({
  providedIn: 'root'
})
export class ExerciseGroupService {

  private _baseAddress: string = 'http://localhost:5000/api/exercisegroup';

  constructor(private _client: HttpClient) {
  }

  get(): Observable<Array<IExerciseGroup>> {
    return this._client.get<Array<IExerciseGroup>>(this._baseAddress);
  }

  add(weight: IWeight, recorded: IDateWrapper): Observable<IExerciseGroup> {

    var actualWeight = (weight.stone * 14) + weight.pounds;
    var actualRecorded = recorded.year + '-' + recorded.month + '-' + recorded.day + 'T00:00:00';

    return this._client.put<IExerciseGroup>(this._baseAddress, {
      weight: actualWeight,
      recorded: actualRecorded
    });
  }
}
