export class CurrencyUtils {

    public static StringParaDecimal(input: any): any {
        if (input === null) return 0;

        input = input.replace(/\./g, '');
        input = input.replace(/,/g, '.');
        return parseFloat(input);
    }

    public static DecimalParaString(input: string): any {
        var ret = (input) ? input.toString().replace(".", ",") : null;
        if (ret) {
            var decArr = ret.split(",");
            if (decArr.length > 1) {
                var dec = decArr[1].length;
                if (dec === 1) { ret += "0"; }
            }
        }
        return ret;
    }

   


    public static formatToBRLCurrency(value: any): string {

        let newValue = value.replace(/\D/g, ''); // Remove caracteres não numéricos

        if (newValue.length > 2) {
            newValue = newValue.replace(/(\d)(\d{2})$/, '$1,$2');
        }


        if (newValue.length > 6) {
            newValue = newValue.replace(/(\d)(\d{3})(?=\d)/g, '$1.$2');
        }
        return newValue;

    }

    
}