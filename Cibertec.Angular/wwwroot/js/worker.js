var self = this;

self.onmessage = function (message) {
    
    var elements = message.data.split(',');
    var order = {
        id: elements[0], orderid: elements[1], productid: elements[2],
        unitprice: elements[3], quantity: elements[4]
    };
    self.postMessage(order);
}

