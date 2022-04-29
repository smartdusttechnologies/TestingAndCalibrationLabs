/**
 * jquery.treeSelection.js - multi-level select
 *
 * Written by
 * ----------
 * Windy2000 (windy2006@gmail.com)
 *
 * Licensed under the Apache License Version 2.0
 *
 * Dependencies
 * ------------
 * jQuery (http://jquery.com)
 *
 **/

$.fn.treeSelection = function(options) {
    this.parent().css('position', 'relative');
    let defaults = {
        multiple: false,
        max: 999,
        style: '',
        class: ''
    };
    let opt = $.extend({}, defaults, options || {});
    if(typeof opt.multiple == 'number') {
        opt.max = opt.multiple;
        opt.multiple = true;
    }
    if(this.prop('multiple')) opt.multiple = true;
    if(typeof opt.max != 'number') {
        opt.max = 999;
    }
    let obj = $('<span>')
        .attr('style', this.attr('style'))
        .attr('class', this.attr('class'))
        .addClass('treeSelector');
    let data_grid = $('<div>')
        .attr('style', opt.style)
        .css({
            'width': this.css('width'),
            'top': (this.position().top+parseInt(this.css('height'))),
            'left': this.position().left
        })
        .addClass(opt.class)
        .addClass('treeSelection')
        .addClass('border');
    let obj_type = opt.multiple ? 'checkbox' : 'radio';
    let obj_name = this.attr('name');
    if(opt.multiple) obj_name += '[]';
    this.removeAttr('name');

    this.after(obj);
    this.hide();
    if(!opt.data) {
        opt.data = [];
        let groups = this.find('optgroup');
        if(groups.length>0) {
            groups.each(function(){
                let item = {
                    name: this.label,
                    items: []
                };
                $(this).find('option').each(function(){
                    item.items.push({
                        name: this.innerHTML,
                        value: this.value
                    });
                });
                opt.data.push(item);
            });
        } else {
            this.find('option').each(function(){
                opt.data.push({
                    name: this.innerHTML,
                    value: this.value
                });
            });
        }
    }
    data_grid.appendTo(this.parent()).hide();
    $(window).resize(function(){
        data_grid.width(obj.width());
    });

    let getCode = function(data) {
        let result = '<ul>'
        for(let i=0,m=data.length;i<m;i++) {
            if(typeof data[i] === 'object' && typeof data[i].items != 'undefined') {
                result += '<li>';
                result += '<label data-sub="true">'+data[i].name+'</label>';
                result += getCode(data[i].items);
            } else {
                if(typeof data[i] === 'string') data[i] = {name: data[i]};
                if(typeof data[i].value == 'undefined') data[i].value = data[i].name;
                result += '<li class="no-sign">';
                result += '<label><input name="'+obj_name+'" type="'+obj_type+'" value="'+data[i].value+'" data-text="'+data[i].name+'"> '+data[i].name+'</label>'
            }
            result += '</li>';
        }
        result += '</ul>';
        return result;
    };
    data_grid.html(getCode(opt.data));

    obj.on('click', function(e) {
        e.preventDefault();
        e.stopPropagation();
        !e.cancelBubble && (e.cancelBubble = true);
        data_grid.slideToggle();
    });

    $('body').click(function(){
        data_grid.slideUp();
    });

    data_grid.find('label').click(function(e){
        if(opt.multiple) {
            e.stopPropagation();
            !e.cancelBubble && (e.cancelBubble = true);
        }
        if(data_grid.find('input:checked').length > opt.max) {
            alert('Max Options Allowed To Select: '+opt.max+'!');
            e.preventDefault();
            return false;
        }
        obj.empty();
        data_grid.find('input:checked').each(function(){
            let val = this.value;
            let item = $('<b>'+$(this).attr('data-text')+'<span>X</span></b>');
            item.appendTo(obj);
            item.find('span').click(function(e){
                e.preventDefault();
                item.remove();
                data_grid.find('input[value="'+val+'"]').prop('checked', false);
                return false;
            });
        })
    });


};
