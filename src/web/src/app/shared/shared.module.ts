import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { DatePickerComponent } from './date-picker/date-picker.component';
import { FormsModule } from '@angular/forms';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import { WeightPipe } from './pipes/weight.pipe';

@NgModule({
  declarations: [
    DatePickerComponent,
    SubmitButtonComponent,
    WeightPipe
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
    NgbModule
  ]
})
export class SharedModule { }
