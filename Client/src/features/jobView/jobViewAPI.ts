import axios, {
  AxiosError,
  AxiosResponse,
  AxiosRequestConfig,
  AxiosPromise
} from 'axios';


var baseURL = "http://localhost:44316/api/";
export function fetchJobViewData(fromDate: string, toDate: string): any {
  return fetch(baseURL + "JobView/GetJobViewData?" + new URLSearchParams({ fromDate, toDate }))
    .then(res => {
      var json = res.json();
      return json;
    })
    .catch(error => {
      return error;
    })
}

export function fetchJobViewData2(fromDate: Date, toDate: Date): any {
  axios.get(baseURL + "JobView/GetJobViewData")
    .then(function (response) {
      console.log(response);
    })
    .catch(function (error) {
      console.log(error);
    })
    .then(function () {
      // always executed
    });
}