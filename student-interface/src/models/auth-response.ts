export interface AuthResponseDto {
  token: string;
  userId: number;
  username: string;
  email: string;
  userType: string;
  birthday: string; // Angular will receive this as ISO string
}
