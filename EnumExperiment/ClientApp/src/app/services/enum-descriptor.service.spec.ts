import { TestBed } from '@angular/core/testing';

import { EnumDescriptorService } from './enum-descriptor.service';

describe('EnumDescriptorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EnumDescriptorService = TestBed.get(EnumDescriptorService);
    expect(service).toBeTruthy();
  });
});
