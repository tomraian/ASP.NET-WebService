﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="DangNhap" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <title>Log In | Hyper - Responsive Bootstrap 4 Admin Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
    <meta content="Coderthemes" name="author" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="../assets//images/favicon.ico">

    <!-- App css -->
    <link href="../assets//css/icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets//css/app.min.css" rel="stylesheet" type="text/css" id="light-style" />
    <link href="../assets//css/app-dark.min.css" rel="stylesheet" type="text/css" id="dark-style" />

</head>

<body class=" authentication-bg"
    data-layout-config='{"leftSideBarTheme":"dark","layoutBoxed":false, "leftSidebarCondensed":false, "leftSidebarScrollable":false,"darkMode":false, "showRightSidebarOnStart": true}'>
    <asp:Label ID="Debug" runat="server" />
    <form action="" id="id" runat="server">
        <div class="account-pages mt-5 mb-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-5">
                        <div class="card">

                            <!-- Logo -->
                            <div class="card-header pt-4 pb-4 text-center bg-primary">
                                <a href="index.html">
                                    <span>
                                        <img src="../assets//images/logo.png" alt="" height="18"></span>
                                </a>
                            </div>

                            <div class="card-body p-4">

                                <div class="text-center w-75 m-auto">
                                    <h4 class="text-dark-50 text-center mt-0 font-weight-bold">Đăng nhập</h4>
                                    <p class="text-muted mb-4">
                                        Đăng nhập để truy cập vào khu vực quản trị
                                    </p>
                                </div>
                                <div class="form-group">
                                    <label for="emailaddress">Email address</label>
                                    <input class="form-control" type="email" id="emailaddress" value="admin@gmail.com"
                                        placeholder="Enter your email" runat="server">
                                </div>

                                <div class="form-group">
                                    <a href="pages-recoverpw.html" class="text-muted float-right"><small>Forgot
                                                your
                                                password?</small></a>
                                    <label for="password">Password</label>
                                    <div class="input-group input-group-merge">
                                        <input type="text" value="123" id="password" class="form-control"
                                            placeholder="Enter your password" runat="server">
                                        <div class="input-group-append" data-password="false">
                                            <div class="input-group-text">
                                                <span class="password-eye"></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group mb-0 text-center">
                                    <asp:Button class="btn btn-primary" runat="server" ID="BtnDangNhap" OnClick="BtnDangNhap_Click" Text="Log In"></asp:Button>
                                    <%--                                        <asp:Button ID="Button1" runat="server" Text="Button" />--%>
                                </div>
                            </div>
                            <!-- end card-body -->
                        </div>
                        <!-- end card -->

                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <p class="text-muted">
                                    Don't have an account? <a href="pages-register.html"
                                        class="text-muted ml-1"><b>Sign Up</b></a>
                                </p>
                            </div>
                            <!-- end col -->
                        </div>
                        <!-- end row -->

                    </div>
                    <!-- end col -->
                </div>
                <!-- end row -->
            </div>
            <!-- end container -->
        </div>
    </form>
    <!-- end page -->

    <footer class="footer footer-alt">
        2018 - 2020 © Hyper - Coderthemes.com
    </footer>

    <!-- bundle -->
    <script src="../assets//js/vendor.min.js"></script>
    <script src="../assets//js/app.min.js"></script>

</body>

</html>
