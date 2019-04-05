import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExportWarehousesComponent } from './export-warehouses.component';

describe('ExportWarehousesComponent', () => {
  let component: ExportWarehousesComponent;
  let fixture: ComponentFixture<ExportWarehousesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExportWarehousesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExportWarehousesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
