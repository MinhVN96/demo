import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportWarehousesComponent } from './import-warehouses.component';

describe('ImportWarehousesComponent', () => {
  let component: ImportWarehousesComponent;
  let fixture: ComponentFixture<ImportWarehousesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImportWarehousesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportWarehousesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
