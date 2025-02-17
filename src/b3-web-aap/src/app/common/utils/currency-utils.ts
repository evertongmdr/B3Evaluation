export class CurrencyUtils {

    public static StringParaDecimal(input: any): number {
        if (!input) return 0;
    
        // Remove qualquer prefixo de moeda e espaços extras
        input = input.toString().replace(/^[^\d]+/, '');
    
        // Remove os pontos dos milhares e substitui a vírgula decimal por ponto
        input = input.replace(/\./g, '').replace(',', '.');
    
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
        let newValue = value.toString().replace(/\D/g, ''); // Remove caracteres não numéricos
    
        // Adiciona a vírgula antes das duas últimas casas decimais
        newValue = newValue.replace(/(\d{2})$/, ',$1');
    
        // Adiciona os pontos de milhar corretamente
        newValue = newValue.replace(/(\d)(?=(\d{3})+(,))/g, '$1.');
    
        return `R$ ${newValue}`;
    }

    public static parseBRLToDecimal(value: string): number {
        if (!value) return 0;
        
        // Remove os pontos de milhar e substitui a vírgula decimal por um ponto
        let newValue = value.replace(/\./g, '').replace(',', '.');
        
        // Converte para número decimal
        return parseFloat(newValue);
    }

    static formatToBRL(value: number | string | undefined): string {
        if (value === undefined || value === null) return "R$ 0,00";
        return Number(value).toLocaleString("pt-BR", {
          style: "currency",
          currency: "BRL",
        });
      }
    

    
}