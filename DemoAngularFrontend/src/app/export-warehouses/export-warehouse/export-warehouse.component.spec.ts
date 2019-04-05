import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExportWarehouseComponent } from './export-warehouse.component';

describe('ExportWarehouseComponent', () => {
  let component: ExportWarehouseComponent;
  let fixture: ComponentFixture<ExportWarehouseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExportWarehouseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExportWarehouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
