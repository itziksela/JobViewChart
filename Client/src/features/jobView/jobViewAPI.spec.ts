import { fetchJobViewData } from './jobViewAPI';

describe('counter reducer', () => {
  const fromDate: string = '1/1/2022';
  const toDate: string = '3/1/2022';
  it('should get some job view data', () => {
    var response = fetchJobViewData(fromDate, toDate);
    return response;
  });
});
