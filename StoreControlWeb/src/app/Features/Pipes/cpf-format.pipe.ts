import { Pipe, PipeTransform } from "@angular/core";

@Pipe({ name: "cpfFormat" })
export class CPFFormatPipe implements PipeTransform {
    transform(value: string): string {
        if (value.length === 11) {
            var newVal = value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g,"\$1.\$2.\$3\-\$4");;
            return newVal;
        } else
            return value;
    }
}