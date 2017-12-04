

var Event = {
    //检测绑定事件
    addHandler: function (element, type, handler) {
        if (element.addEventListener) {
            element.addEventListener(type, handler, false);

        } else if (element.attachEvent) {
            element.attachEvent('on' + type, handler);
        } else {
            element['on' + type] = handler;
        }
    },
    //取消绑定事件
    removeHandler: function (element, type, handler) {
        if (element.removeEventListener) {
            element.removeEventListener(typ,handler,false);
        } else if (element.detachEvent) {
            element.detachEvent('on'+type,handler);
        } else {
            element['on' + type] = null;
        }
    },
    //取消冒泡事件
    cancel: function (event) {
        if (e.stopPropagation) {
            e.stopPropagation();
        } else {
            e.cancelBubble = true;
        }
    },
    //取消默认行为
    preventDefault: function (event) {
        if (event.preventDefault) {
            event.preventDefault();
        } else {
            event.returnValue = false;
        }
    },
    //得到对象
    getEvent: function (event) {
        return event ? event : window.event;
    },
    getTarget: function (event) {
        return event.target || event.srcElement;
    }

}