import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IExerciseGroup } from '../models/exercise-group';
import { IDateWrapper } from '../models/date-wrapper';
import { IWeight } from '../models/weight';
import { IExerciseGroupPeriod } from '../models/exercise-group-period';
import { IExerciseGroupSummary } from '../models/exercise-group-summary';
import { IExerciseGroupResult } from '../models/exercise-group-result';


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

        let mappedSummaries = new Array<IExerciseGroupSummary>();

        period.summaries.forEach(summary => {
          mappedSummaries.push({
            id: summary.id,
            recorded: summary.recorded,
            weight: summary.weight,
            canDelete: summary.canDelete,
            startDate: summary.startDate,
            exerciseCount: summary.exerciseCount,
            isExpanded: false
          })
        });

        mapped.push({
          title: period.title,
          year: period.year,
          month: period.month,
          totalWeightLost: period.totalWeightLost,
          summaries: mappedSummaries,
          isExpanded: true
        });
      });

      return mapped;
    });

    return mapExerciseGroupPeriods(this._client.get<Array<IExerciseGroupPeriod>>(url));
  }

  getById(id: string): Observable<IExerciseGroupResult> {
    return this._client.get<IExerciseGroupResult>(`${this._baseAddress}${id}`);
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
