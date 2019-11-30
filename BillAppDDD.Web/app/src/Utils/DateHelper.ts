export const GetDateStringFromInput=(input:string):string=>{
    let date = new Date(input);
    let dateString = date.getFullYear() + '-' + date.getMonth().toString().padStart(2, '0') + '-' + date.getDate().toString().padStart(2, '0');
    return dateString;
}