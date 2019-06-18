import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { DatePickerComponent } from './date-picker/date-picker.component';
import { FormsModule } from '@angular/forms';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import { WeightPipe } from './pipes/weight.pipe';
import { TimeDifferencePipe } from './pipes/time-difference.pipe';

@NgModule({
  declarations: [
    DatePickerComponent,
    SubmitButtonComponent,
    WeightPipe,
    TimeDifferencePipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    NgbModule
  ],
  exports: [
    DatePickerComponent,
    SubmitButtonComponent,
    WeightPipe,
    TimeDifferencePipe,
    NgbModule
  ]
})
export class SharedModule { }
