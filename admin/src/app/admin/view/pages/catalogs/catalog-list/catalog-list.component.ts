import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  AfterViewInit
} from "@angular/core";
import { MatPaginator, MatSort, MatDialog } from "@angular/material";
import { fromEvent, merge } from "rxjs";
import { debounceTime, distinctUntilChanged, tap } from "rxjs/operators";
import { DataSourcceCatalogs } from "src/app/admin/core/datasource/datasourceCatalogs.datasource";
import { CatalogsService } from "src/app/admin/core/services/catalogs.service";
import { DialogComponent } from "../../../partials/dialog/dialog.component";

@Component({
  selector: "app-catalog-list",
  templateUrl: "./catalog-list.component.html",
  styleUrls: ["./catalog-list.component.scss"]
})
export class CatalogListComponent implements AfterViewInit, OnInit {
  catalogsCount: number;

  dataSource: DataSourcceCatalogs;
  displayedColumns = [
    "Id",
    "Name",
    "ShortDescription",
    "Description",
    "Visibility",
    "CreateAt",
    "UpdateAt",
    "Action"
  ];

  displayedSelects = ["Name", "ShortDescription", "Description"];
  selectedValue = "Name";

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild("input", { static: true }) input: ElementRef;

  constructor(
    private catalogsService: CatalogsService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.dataSource = new DataSourcceCatalogs(this.catalogsService);
    this.dataSource.loadData();
    this.dataSource.dataSubject.subscribe(
      res => (this.catalogsCount = res.length)
    );
  }

  ngAfterViewInit() {
    // SEARCH
    fromEvent(this.input.nativeElement, "keyup")
      .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {
          this.paginator.pageIndex = 0;
          this.loadCatalogs();
        })
      )
      .subscribe();

    // reset the paginator after sorting
    this.sort.sortChange.subscribe(() => (this.paginator.pageIndex = 0));

    // on sort or paginate events, load a new page
    merge(this.sort.sortChange, this.paginator.page)
      .pipe(tap(() => this.loadCatalogs()))
      .subscribe();
  }

  loadCatalogs() {
    this.dataSource.loadData(
      this.paginator.pageIndex + 1,
      this.paginator.pageSize,
      this.sort.active,
      this.sort.direction,
      this.selectedValue,
      this.input.nativeElement.value
    );
  }

  onDelete(id) {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: "400px",
      data: { title: "Delete Product", desc: "Delete" },
      disableClose: true,
      panelClass: "custom-dialog"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.catalogsService
          .deleteCatalog(id)
          .subscribe(() => this.loadCatalogs());
      }
    });
  }
}
