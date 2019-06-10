import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseGroupSummaryComponent } from './exercise-group-summary.component';

describe('ExerciseGroupSummaryComponent', () => {
  let component: ExerciseGroupSummaryComponent;
  let fixture: ComponentFixture<ExerciseGroupSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExerciseGroupSummaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseGroupSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
