import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IExerciseGroup } from '../models/exercise-group';


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
}
