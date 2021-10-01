import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MbHomePageComponent } from './mb-home-page.component';

describe('MbHomePageComponent', () => {
  let component: MbHomePageComponent;
  let fixture: ComponentFixture<MbHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MbHomePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MbHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
