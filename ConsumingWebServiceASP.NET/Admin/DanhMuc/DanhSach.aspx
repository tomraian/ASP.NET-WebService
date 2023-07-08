<%@ Page Title="Danh sách danh mục" Language="C#" MasterPageFile="~/Admin/TrangChu/Admin.master" AutoEventWireup="true" CodeFile="DanhSach.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cssContent" runat="Server">
 <!-- datatable  -->
    <link href="../../assets/css/vendor/dataTables.bootstrap4.css" rel="stylesheet" type="text/css" />
    <link href="../../assets/css/vendor/responsive.bootstrap4.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <table id="basic-datatable" class="table dt-responsive nowrap w-100">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Tên danh mục</th>
                        <th>Sửa</th>
                        <th>Xóa</th>
                    </tr>
                </thead>


                <tbody>
                    <tr>
                        <td>No.1</td>
                        <td>System Architect</td>
                        <td>
                            <button type="button" class="btn btn-primary">Sửa</button>
                        </td>
                        <td>
                            <button type="button" class="btn btn-danger">Xóa</button>
                        </td>
                    </tr>
                    <tr>
                        <td>No.2</td>
                        <td>Accountant</td>
                         <td>
                            <button type="button" class="btn btn-primary">Sửa</button>
                        </td>
                        <td>
                            <button type="button" class="btn btn-danger">Xóa</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="jsContent" runat="Server">
   <!-- Datatables js -->
    <script src="../../assets/js/vendor/jquery.dataTables.min.js"></script>
    <script src="../../assets/js/vendor/dataTables.bootstrap4.js"></script>
    <script src="../../assets/js/vendor/dataTables.responsive.min.js"></script>
    <script src="../../assets/js/vendor/responsive.bootstrap4.min.js"></script>

    <!-- Datatable Init js -->
    <script src="../../assets/js/pages/demo.datatable-init.js"></script>

</asp:Content>
