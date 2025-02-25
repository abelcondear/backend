function formatDate(d) {
  let date = new Date();
  let result = new String();

  let day = d.getDate();
  let month = d.getMonth() + 1;
  let year = d.getFullYear();

  if(month < 10) {
    result = `${day}-0${month}-${year}`;
  } else {
    result = `${day}-${month}-${year}`;
  }

  return result;
}

date = new Array();

date.push(new Date('01/07/2002'));
date.push(new Date('01/03/2003'));
date.push(new Date('01/10/2004'));
date.push(new Date('01/01/2005'));
date.push(new Date('01/05/2006'));
date.push(new Date('06/01/2006'));
date.push(new Date('01/01/2007'));
date.push(new Date('03/01/2007'));
date.push(new Date('04/01/2009'));
date.push(new Date('05/01/2009'));
date.push(new Date('09/01/2009'));
date.push(new Date('12/01/2009'));
date.push(new Date('11/01/2010'));
date.push(new Date('12/01/2010'));
date.push(new Date('12/01/2011'));
date.push(new Date('12/01/2011'));
date.push(new Date('03/01/2015'));
date.push(new Date('03/01/2015'));
date.push(new Date('01/01/2016'));
date.push(new Date('04/01/2016'));
date.push(new Date('09/01/2019'));
date.push(new Date('10/01/2019'));

//console.log(date);

let next = 0;

for (let cur = 0; cur < date.length; cur ++) {
  next += 1;

  if (next >= date.length) {
    break;
  }

  diffTime = Math.abs(date[next] - date[cur]);
  diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)); 
  diffMonths = Math.floor(diffDays / 30);

  console.log(formatDate(date[cur]));
  console.log(formatDate(date[next]));
  console.log(diffMonths);
  console.log('-------------------------');
}
