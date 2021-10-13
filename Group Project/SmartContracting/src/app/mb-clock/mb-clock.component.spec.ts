import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MbClockComponent } from './mb-clock.component';

describe('MbClockComponent', () => {
  let component: MbClockComponent;
  let fixture: ComponentFixture<MbClockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MbClockComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MbClockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
