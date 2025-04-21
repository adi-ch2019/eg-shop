import { ComponentFixture, TestBed } from '@angular/core/testing';
import { VegetableGridComponent } from './vegetable-grid.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';

describe('VegetableGridComponent', () => {
  let component: VegetableGridComponent;
  let fixture: ComponentFixture<VegetableGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VegetableGridComponent, MatTableModule, MatButtonModule] // ✅ Import instead of declare
    }).compileComponents();

    fixture = TestBed.createComponent(VegetableGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should increase quantity when increaseQuantity is called', () => {
    component.increaseQuantity('Carrot');
    expect(component.vegetables.find(v => v.name === 'Carrot')?.quantity).toBe(1);
  });

  it('should decrease quantity when decreaseQuantity is called', () => {
    component.vegetables.find(v => v.name === 'Carrot')!.quantity = 2;
    component.decreaseQuantity('Carrot');
    expect(component.vegetables.find(v => v.name === 'Carrot')?.quantity).toBe(1);
  });

  it('should not decrease quantity below zero', () => {
    component.decreaseQuantity('Carrot');
    expect(component.vegetables.find(v => v.name === 'Carrot')?.quantity).toBe(0);
  });
});