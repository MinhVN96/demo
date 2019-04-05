import { TestBed } from '@angular/core/testing';

import { ExportWarehouseService } from './export-warehouse.service';

describe('ExportWarehouseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ExportWarehouseService = TestBed.get(ExportWarehouseService);
    expect(service).toBeTruthy();
  });
});
