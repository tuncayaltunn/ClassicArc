import { Pipe, PipeTransform } from '@angular/core';
import { Product } from '../models/product';
import { filter } from 'rxjs';

@Pipe({
  name: 'filterPipe'
})
export class FilterPipePipe implements PipeTransform {

  transform(value: Product[], filterText: string): Product[] {

    filterText = filterText ? filterText.toLocaleLowerCase() : "";

    return filterText ? value.filter((p : Product) => p.product_name.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }

}
