import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MbProfileComponent } from './mb-profile.component';

describe('MbProfileComponent', () => {
  let component: MbProfileComponent;
  let fixture: ComponentFixture<MbProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MbProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MbProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
