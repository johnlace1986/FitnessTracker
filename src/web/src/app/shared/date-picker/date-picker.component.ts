import { Component, OnInit, Input } from '@angular/core';
import { IDateWrapper } from 'src/app/models/date-wrapper';

@Component({
  selector: 'ft-date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.css']
})
export class DatePickerComponent implements OnInit {

  @Input()
  public value: IDateWrapper;
  
  @Input()
  public minYears: number;
  
  @Input()
  public maxYears: number;

  @Input()
  public disabled: Boolean = false;

  constructor() { }

  ngOnInit() {
  }

}
