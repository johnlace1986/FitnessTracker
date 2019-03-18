import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseGroupPeriodComponent } from './exercise-group-period.component';

describe('ExerciseGroupPeriodComponent', () => {
  let component: ExerciseGroupPeriodComponent;
  let fixture: ComponentFixture<ExerciseGroupPeriodComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExerciseGroupPeriodComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseGroupPeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
