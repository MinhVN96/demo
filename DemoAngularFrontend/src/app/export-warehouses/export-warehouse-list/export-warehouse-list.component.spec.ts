import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExportWarehouseListComponent } from './export-warehouse-list.component';

describe('ExportWarehouseListComponent', () => {
  let component: ExportWarehouseListComponent;
  let fixture: ComponentFixture<ExportWarehouseListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExportWarehouseListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExportWarehouseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
