import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportWarehouseListComponent } from './import-warehouse-list.component';

describe('ImportWarehouseListComponent', () => {
  let component: ImportWarehouseListComponent;
  let fixture: ComponentFixture<ImportWarehouseListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImportWarehouseListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportWarehouseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
