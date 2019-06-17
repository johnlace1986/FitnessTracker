import { Component, OnInit } from '@angular/core';
import { ExerciseGroupService } from '../services/exercise-group.service';
import { IExerciseGroupPeriod } from '../models/exercise-group-period';

@Component({
  selector: 'ft-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public errorMessage: string;
  public periods: Array<IExerciseGroupPeriod> = new Array<IExerciseGroupPeriod>();
  public canShowMore: Boolean = true;

  private _offset: number = 0;

  constructor(private _service: ExerciseGroupService) { }

  ngOnInit() {
    this.showMore();
  }

  showMore() {
    this.errorMessage = '';

    this._service.get(this._offset)
      .subscribe(periods => {
        if (periods.length == 0) {
          this.canShowMore = false;
        }
        else {
          periods.forEach(newPeriod => {            
            var actualPeriod: IExerciseGroupPeriod = null;

            this.periods.forEach(currentPeriod => {
              if (currentPeriod.year == newPeriod.year && currentPeriod.month == newPeriod.month) {
                actualPeriod = currentPeriod;
              }
            });

            if (actualPeriod) {
              newPeriod.summaries.forEach(summary => {
                actualPeriod.summaries.push(summary);
              });
            }
            else {
              this.periods.push(newPeriod)
            }

            this._offset += newPeriod.summaries.length;
          });
        }
      },
      () => {
        this.errorMessage = 'Unable to load data. An error occurred on the server.'
      });
  }
}
