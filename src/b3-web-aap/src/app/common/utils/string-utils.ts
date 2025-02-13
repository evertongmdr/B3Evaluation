export class StringUtils {

    public static isNullOrEmpty(val: string): boolean {
        if (val === undefined || val === null || val.trim() === '') {
            return true;
        }
        return false;
    };

    public static onlyNumbers(numero: string): string {
        return numero.replace(/[^0-9]/g, '');
    }

    public static stringToInt(str: string) {
        const num = parseInt(str, 10);
        return isNaN(num) ? 0 : num;
    }
}

