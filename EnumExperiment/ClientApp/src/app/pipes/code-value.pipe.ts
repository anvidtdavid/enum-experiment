import { Pipe, PipeTransform } from '@angular/core';
import { EnumDescriptorService } from '../services/enum-descriptor.service';

@Pipe({
  name: 'codeValue'
})
export class CodeValuePipe implements PipeTransform {

  constructor(private enumService: EnumDescriptorService) {
  }

  transform(value: any, ...args: any[]): any {
    if (value === null || value === undefined) {
      return null;
    }

    return this.enumService.getValue(args[0], value, (args[1] === undefined ? args[1] : false), (args[2] ? args[2] : null));
  }

}
