<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <title>Đăng nhập</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
    <meta content="Coderthemes" name="author" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="../assets/images/favicon.ico">

    <!-- App css -->
    <link href="../assets/css/icons.min.css" rel="shortcut icon" type="image/x-icon" />
    <link href="../assets/css/icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/app.min.css" rel="stylesheet" type="text/css" id="light-style" />
    <link href="../assets/css/app-dark.min.css" rel="stylesheet" type="text/css" id="dark-style" />


</head>

<body class="loading authentication-bg"
    data-layout-config='{"leftSideBarTheme":"dark","layoutBoxed":false, "leftSidebarCondensed":false, "leftSidebarScrollable":false,"darkMode":false, "showRightSidebarOnStart": true}'>
    <div class="account-pages mt-5 mb-5">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-5">
                    <div class="card">
                        <!-- Logo -->
                        <div class="card-header pt-4 pb-4 text-center bg-primary">
                            <a href="index.html">
                                <span><img src="../assets/images/logo.png" alt="" height="18"></span>
                            </a>
                        </div>

                        <div class="card-body p-4">

                            <div class="text-center w-75 m-auto">
                                <h4 class="text-dark-50 text-center mt-0 font-weight-bold">Đăng nhập</h4>
                                <p class="text-muted mb-4">Nhập email và mật khẩu để đăng nhập vào khu vực quản trị
                                </p>
                            </div>

                            <form action="#">

                                <div class="form-group">
                                    <label for="emailaddress">Email</label>
                                    <input class="form-control" type="email" id="emailaddress" required=""
                                        placeholder="Nhập email">
                                </div>

                                <div class="form-group">
                                    <a href="#" class="text-muted float-right"><small>Quên mật khẩu?</small></a>
                                    <label for="password">Mật khẩu</label>
                                    <div class="input-group input-group-merge">
                                        <input type="password" id="password" class="form-control"
                                            placeholder="Nhập mật khẩu">
                                        <div class="input-group-append" data-password="false">
                                            <div class="input-group-text">
                                                <span class="password-eye"></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%-- <div class="form-group mb-3">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="checkbox-signin"
                                            checked>
                                        <label class="custom-control-label" for="checkbox-signin">Remember me</label>
                                    </div>
                                </div> --%>

                                <div class="form-group mb-0 text-center">
                                    <button class="btn btn-primary" type="submit"> Đăng nhập </button>
                                </div>

                            </form>
                        </div> <!-- end card-body -->
                    </div>
                    <!-- end card -->

                    <div class="row mt-3">
                        <div class="col-12 text-center">
                            <p class="text-muted">Bạn chưa có tài khoản? <a href="pages-register.html"
                                    class="text-muted ml-1"><b>Đăng ký</b></a></p>
                        </div> <!-- end col -->
                    </div>
                    <!-- end row -->

                </div> <!-- end col -->
            </div>
            <!-- end row -->
        </div>
        <!-- end container -->
    </div>
    <!-- end page -->

    <footer class="footer footer-alt">
        2023 - <%: DateTime.Now.Year %> © Duy-Dinh-Bảo
    </footer>

    <!-- bundle -->
    <script src="../assets/js/vendor.min.js"></script>
    <script src="../assets/js/app.min.js"></script>

</body>

</html>