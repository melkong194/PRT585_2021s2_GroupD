import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActPageComponent } from './act-page.component';

describe('ActPageComponent', () => {
  let component: ActPageComponent;
  let fixture: ComponentFixture<ActPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
