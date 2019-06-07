import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IExerciseGroup } from '../models/exercise-group';
import { IDateWrapper } from '../models/date-wrapper';
import { IWeight } from '../models/weight';
import { IExerciseGroupPeriod } from '../models/exercise-group-period';


@Injectable({
  providedIn: 'root'
})
export class ExerciseGroupService {

  private _baseAddress: string = 'http://localhost:5000/api/exercisegroup/';

  constructor(private _client: HttpClient) {
  }

  get(offset: number): Observable<Array<IExerciseGroupPeriod>> {

    var url = `${this._baseAddress}?limit=10`;

    if (offset) {
      url += `&offset=${offset}`;
    }

    const mapExerciseGroupPeriods = map((periods: Array<IExerciseGroupPeriod>) => {
      let mapped = new Array<IExerciseGroupPeriod>();

      periods.forEach(period => {
        mapped.push({
          title: period.title,
          year: period.year,
          month: period.month,
          totalWeightLost: period.totalWeightLost,
          summaries: period.summaries,
          isCollapsed: true
        });
      });

      return mapped;
    });

    return mapExerciseGroupPeriods(this._client.get<Array<IExerciseGroupPeriod>>(url));
  }

  add(recorded: IDateWrapper, weight: IWeight): Observable<IExerciseGroup> {

    var actualRecorded = recorded.year + '-' + recorded.month + '-' + recorded.day + 'T00:00:00';
    var actualWeight = (weight.stone * 14) + weight.pounds;

    return this._client.post<IExerciseGroup>(this._baseAddress, {
      recorded: actualRecorded,
      weight: actualWeight
    });
  }
}
