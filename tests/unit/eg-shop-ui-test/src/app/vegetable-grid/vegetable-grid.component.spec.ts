import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VegetableGridComponent } from './vegetable-grid.component';

describe('VegetableGridComponent', () => {
  let component: VegetableGridComponent;
  let fixture: ComponentFixture<VegetableGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VegetableGridComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VegetableGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
