import { TestBed } from '@angular/core/testing';

import { ImportWarehouseService } from './import-warehouse.service';

describe('ImportWarehouseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ImportWarehouseService = TestBed.get(ImportWarehouseService);
    expect(service).toBeTruthy();
  });
});
