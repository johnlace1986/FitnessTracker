import { Component, OnInit } from '@angular/core';
import { ExerciseGroupService } from '../services/exercise-group.service';
import { IExerciseGroup } from '../models/exercise-group';

@Component({
  selector: 'ft-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public groups: Array<IExerciseGroup>;

  constructor(private _client: ExerciseGroupService) { }

  ngOnInit() {
    this._client.get()
      .subscribe(groups => {
        this.groups = groups;
      });
  }
}
