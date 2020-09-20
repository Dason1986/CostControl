function enumFormatter() {
    this.StatusCode = function (value) {
        if (value === 1 || value === '1') return '有效';
        if (value === 0 || value === '0') return '未启用';
        if (value === -1 || value === '-1') return '刪除';
        return value;
    },
        this.Boolean = function (value) {
            if (value instanceof Boolean) {
                return value ? '是' : '否';
            }
            if (value === 1 || value === '1') return '是';
            if (value === 0 || value === '0') return '否';
            return value;
        };
}
var _enumFormatter = new enumFormatter();

Vue.mixin({
    methods: {
        isNull: function (value) {
            if (value === null || value === undefined || value.length === 0) return true;

            return false;
        },
        formatterStatusCode: function (row, column, cell) { return _enumFormatter.StatusCode(cell); },
        formatterBoolean: function (row, column, cell) { return _enumFormatter.Boolean(cell); },
        formatterNumber: function (row, column, cell) { if (cell === null || cell === undefined || cell === 0) return ''; return cell },
    },
    filters: {
      
        filterStatusCode: function (value) {
            return _enumFormatter.StatusCode(value);
           
        },
        filterBoolean: function (value) {
            return _enumFormatter.Boolean(value);
        },
      
    }
})
const DYVue = {

    install: function (Vue, options) {
      

        Vue.http.options.credentials = true;
        Vue.http.interceptors.push(function (request, next) {

            request.headers.set('Cache-Control', 'no-store');



            next(function (response) {


                if (!response.ok) {


                    if (response.status === 0) {
                        Vue.prototype.$notify({ title: "连接服务失败", message: response.data, type: "error" });
                    }
                    if (response.status === 400) {
                        if (response.data.errors) {
                            var msg = '';
                            for (var i in response.data.errors) {
                                msg += response.data.errors[i][0] + '\r\n';
                            }

                            Vue.prototype.$notify({ title: '提交信息有误', message: msg, type: "error" });
                            throw new Error(msg);
                        }
                        if (response.data.message) {
                          

                            Vue.prototype.$notify({   title: response.data.message, type: "error" });
                            throw new Error(response.data.message);
                        } else {
                            Vue.prototype.$notify({ title: "提交信息有误", message: response.message, type: "error" });
                            throw new Error(response.message);
                        }


                    }
                    if (response.status === 401) {
                        Vue.prototype.$notify({ title: "未登陆",  type: "error" });
                  //      window.open('/Account/Login', '_blank');
                        window.location.href = '/Account/Login';
                        return;


                    }
                    if (response.status === 403) {
                        Vue.prototype.$notify({ title: "资源无权使用", message: response.data, type: "error" });
                        throw new Error('资源无权使用');
                    }
                    if (response.status === 404) {
                        Vue.prototype.$notify({ title: "找不到数据", message: response.data, type: "error" });
                        throw new Error('找不到数据');
                    }
                    if (response.status === 405) {
                        Vue.prototype.$notify({ title: "请求方法无效", message: response.data, type: "error" });                      
                        throw new Error('请求方法无效');
                    }
                    if (response.status === 500) {
                        Vue.prototype.$notify({ title: "后台出错", message: '未知异常，请联系管理员', type: "error" });

                        throw new Error('后台出错！');
                    }
                    else if (response.body) {

                        var modelstate = response.body;
                        if (modelstate) {
                            Vue.prototype.$notify({
                                title: modelstate.message,
                                message: modelstate.reason === null ? '' : modelstate.reason,
                                type: "error"
                            });

                            if (modelstate.message === '系统超时') {
                                window.open('../Account/Login', '_blank');
                            }

                        } else {
                            Vue.prototype.$notify({ title: "错误", message: "未知异常", type: "error" });
                        }

                        return;
                    }


                }


                return response;
            });
        });
    }
};