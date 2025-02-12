export interface ApiResponse<T = any> {
    success: boolean;
    errors: string[];
    data: T | null;
}