import { ComponentFixture, TestBed } from '@angular/core/testing';

import { productdetComponent } from './productdet.component';

describe('productdetComponent', () => {
  let component: productdetComponent;
  let fixture: ComponentFixture<productdetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [productdetComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(productdetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
