import { Component, OnInit } from '@angular/core';
import { ExerciseGroupService } from '../services/exercise-group.service';
import { IExerciseGroup } from '../models/exercise-group';

@Component({
  selector: 'ft-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public errorMessage: string;
  public groups: Array<IExerciseGroup> = new Array<IExerciseGroup>();
  public canShowMore: Boolean = true;

  private _offset: number = 0;

  constructor(private _service: ExerciseGroupService) { }

  ngOnInit() {
    this.showMore();
  }

  showMore() {
    this.errorMessage = '';

    this._service.get(this._offset)
      .subscribe(groups => {

        if (groups.length == 0){
          this.canShowMore = false;
        }
        else {
          groups.forEach((group) => {
            this.groups.push(group);
          });

          this._offset += groups.length;
        }
      },
      () => {
        this.errorMessage = 'Unable to load data. An error occurred on the server.'
      });
  }
}
