import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DatePickerComponent } from './date-picker/date-picker.component';
import { FormsModule } from '@angular/forms';
import { SubmitButtonComponent } from './submit-button/submit-button.component';

@NgModule({
  declarations: [
    DatePickerComponent,
    SubmitButtonComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    DatePickerComponent,
    SubmitButtonComponent
  ]
})
export class SharedModule { }
