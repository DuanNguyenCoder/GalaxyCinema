export interface Breadcrumb {
  label: string;
  url: string;
  selected?: boolean;
}

export interface Seat {
  number: number;
  selected?: boolean;
  row: string;
  ordered?: boolean;
}

export class Customer {
  customerID?: number;
  name?: string;
  birthday?: string;
  address?: string;
  phone?: string;
  sex?: number;
  point?: number;
  email?: string;
  passwords?: string;
  isLogin?: boolean;

  constructor(
    name: string,
    birthday: string,
    address: string,
    phone: string,
    sex: number,
    email: string,
    passwords: string,
    isLogin?: boolean
  ) {
    this.name = name;
    this.birthday = birthday;
    this.address = address;
    this.phone = phone;
    this.sex = sex;
    this.email = email;
    this.point = 0;
    this.passwords = passwords;
    this.isLogin = isLogin;
  }
}

export interface MovieShowTime {
  filmID: number;
  ageLimited?: number;
  image?: any;
  showTimes?: [{ showTimeID: number; timeShow: string; screen: string }];
  time?: string;
  name?: string;
}

export interface Movie {
  filmID: number;
  ageLimited: number;
  image: any;
  showTimeID?: number;
  time: string;
  name: string;
  typefilm?: string;
  description?: string;
  link?: string;
  active?: number;
  screen?: string;
}

export interface DateInfo {
  dayOfWeek: string;
  month: string;
  day: number;
}

export class Bill {
  filmID!: number;
  showTimeID!: number;
  customerID?: number;
  total!: number;
  seat: string[] = [];
  product?: Product[];
  mail?: string;
}

export class Product {
  productID!: number;
  quantity!: number;
  details!: string;
}

export class Review {
  rate?: number;
  rateDate?: any;
  ratingID?: number;
  name?: string;
  comment?: string;
  customerID?: number;
  filmID?: number;

  constructor(
    cusID: number,
    filmID: number,
    name: string,
    date: any,
    rate: number,
    comment: string
  ) {
    this.name = name;
    this.customerID = cusID;
    this.filmID = filmID;
    this.rateDate = date;
    this.rate = rate;
    this.comment = comment;
  }
}
