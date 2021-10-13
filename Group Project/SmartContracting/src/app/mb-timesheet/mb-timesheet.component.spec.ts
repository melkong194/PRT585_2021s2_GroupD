import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MbTimesheetComponent } from './mb-timesheet.component';

describe('MbTimesheetComponent', () => {
  let component: MbTimesheetComponent;
  let fixture: ComponentFixture<MbTimesheetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MbTimesheetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MbTimesheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
